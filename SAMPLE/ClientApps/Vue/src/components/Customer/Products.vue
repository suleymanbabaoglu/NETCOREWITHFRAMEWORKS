<template>
    <div>
        <b-button class="mb-3" variant="primary" @click="add">ADD</b-button>
        <b-table striped hover :items="items" :fields="fields">
            <template #cell(actions)="data">
                <b-icon-trash-fill
                        role="button"
                        @click="removeProduct(data.item.product.id)"
                />
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
    import {ControllerRoutes, CustomerRoutes} from "../../constraints/Routes";
    import AddProduct from "./AddProduct";

    export default {
        props:["customerId"],
        data() {
            return {
                fields: [
                    { key: "product.id" ,label:"ID"},
                    { key: "product.name",label:"Product Name" },
                    { key: "product.brand" ,label:"Product Brand"},
                    { key: "purchaseDate" ,label:"Date Of Purchase"},
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
                this.items = await new BaseActions(ControllerRoutes.Customer).request("GET",CustomerRoutes.GetProducts(this.customerId));
            },
            add() {
                this.modalComponent = {
                    visible: true,
                    props: { customerId: this.customerId },
                    component: AddProduct
                };
            },
            async removeProduct(productId) {
                await new BaseActions(ControllerRoutes.Customer).request("GET",CustomerRoutes.RemoveProduct(this.customerId,productId));
                this.items.splice(
                    this.items.indexOf(this.items.find(c => c.id === productId)),
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

