<template>
  <div>
    <b-button class="mb-3" variant="primary" @click="create">CREATE</b-button>
    <b-table striped hover :items="items" :fields="fields">
      <template #cell(actions)="data">
        <b-icon-pen-fill
          class="mr-3"
          role="button"
          @click="update(data.item.id)"
        />
        <b-icon-trash-fill role="button" @click="deleteProduct(data.item.id)" />
      </template>
    </b-table>
    <b-modal
      centered
      v-model="modalComponent.visible"
      no-close-on-backdrop
      no-close-on-esc
      busy
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
import CreateUpdateForm from "../../components/Product/CreateUpdateForm";

export default {
  data() {
    return {
      fields: [
        { key: "id" },
        { key: "name" },
        { key: "brand" },
        { key: "serialNumber" },
        { key: "actions", label: "Actions" }
      ],
      items: [],
      modalComponent: {
        visible: false,
        component: null,
        props: []
      }
    };
  },
  created() {
    this.initialize();
  },
  methods: {
    async initialize() {
      this.items = await new BaseActions(ControllerRoutes.Product).getAll();
    },
    create() {
      this.modalComponent = {
        visible: true,
        props: { create: true },
        component: CreateUpdateForm
      };
    },
    update(productId) {
      this.modalComponent = {
        visible: true,
        props: { create: false, productId: productId },
        component: CreateUpdateForm
      };
    },
    async deleteProduct(productId) {
      await new BaseActions(ControllerRoutes.Product).delete(productId);
      this.items.splice(
        this.items.indexOf(this.items.find(p => p.id === productId)),
        1
      );
    },
    closeModal() {
      this.modalComponent.visible = false;
      this.initialize();
    }
  }
};
</script>
