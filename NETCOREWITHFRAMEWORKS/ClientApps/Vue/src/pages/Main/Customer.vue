<template>
  <div>
    <b-button class="mb-3" variant="primary" @click="create">CREATE</b-button>
    <b-table striped hover :items="items" :fields="fields">
      <template #cell(actions)="data">
        <b-icon-bag-fill class="mr-3" role="button" @click="products(data.item.id)" />
        <b-icon-pen-fill class="mr-3" role="button" @click="update(data.item.id)" />
        <b-icon-trash-fill
          role="button"
          @click="deleteCustomer(data.item.id)"
        />
      </template>
    </b-table>
    <b-modal
      centered
      v-model="modalComponent.visible"
      no-close-on-backdrop
      no-close-on-esc
      busy
      :size="modalComponent.size"
    >
      <component
        :is="modalComponent.component"
        v-bind="modalComponent.props"
        @closeModal="closeModal"
      />
      <template #modal-footer>
        <div></div>
      </template>
    </b-modal>
  </div>
</template>

<script>
import BaseActions from "../../store/BaseActions";
import { ControllerRoutes } from "../../constraints/Routes";
import CreateUpdateForm from "../../components/Customer/CreateUpdateForm";
import Products from "../../components/Customer/Products";

export default {
  data() {
    return {
      fields: [
        { key: "id" },
        { key: "user.firstName", label: "First Name" },
        { key: "user.lastName", label: "Last Name" },
        { key: "user.email", label: "E-Mail" },
        { key: "companyName", label: "Company Name" },
        { key: "actions", label: "Actions" }
      ],
      items: [],
      modalComponent: {
        visible: false,
        component: null,
        props: [],
        size:""
      }
    };
  },
  created() {
    this.initialize();
  },
  methods: {
    async initialize() {
      this.items = await new BaseActions(ControllerRoutes.Customer).getAll();
    },
    create() {
      this.modalComponent = {
        visible: true,
        props: { create: true },
        component: CreateUpdateForm
      };
    },
    update(customerId) {
      this.modalComponent = {
        visible: true,
        props: { create: false, customerId: customerId },
        component: CreateUpdateForm
      };
    },
    async deleteCustomer(customerId) {
      await new BaseActions(ControllerRoutes.Customer).delete(customerId);
      this.items.splice(
        this.items.indexOf(this.items.find(c => c.id === customerId)),
        1
      );
    },
    products(customerId){
      this.modalComponent = {
        visible: true,
        props: { customerId: customerId },
        component: Products,
        size: "xl"
      };
    },
    closeModal() {
      this.modalComponent.visible = false;
      this.initialize();
    }
  }
};
</script>
<style scoped>
</style>
