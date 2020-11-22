<template>
  <div>
    <b-card bg-variant="light">
      <b-form-group
        label-cols-lg="12"
        label="Settings"
        label-size="lg"
        label-class="font-weight-bold pt-1"
        class="mb-0"
      >
        <b-form-group
          label-cols-sm="3"
          label="Title :"
          label-align-sm="left"
          label-for="nested-title"
        >
          <b-form-input id="nested-title" required v-model="settings.title" />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="Client App :"
          label-align-sm="left"
          label-for="nested-nav-var"
        >
          <b-form-select
            v-model="settings.clientApp"
            :options="clientApps"
            value-field="key"
            text-field="value"
            required
          />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="Navbar Variant :"
          label-align-sm="left"
          label-for="nested-nav-var"
        >
          <b-form-select
            v-model="settings.navbarVariant"
            :options="variants"
            value-field="key"
            text-field="value"
            required
          />
        </b-form-group>

        <b-form-group
          label-cols-sm="3"
          label="Sidebar Variant :"
          label-align-sm="left"
          label-for="nested-sd-var"
        >
          <b-form-select
            v-model="settings.sidebarVariant"
            :options="variants"
            value-field="key"
            text-field="value"
            required
          />
        </b-form-group>

        <b-form-group>
          <b-button
            variant="primary"
            size="md"
            class="mt-3"
            style="width: 100%"
            @click="onSubmit()"
            >UPDATE
          </b-button>
        </b-form-group>
      </b-form-group>
    </b-card>
  </div>
</template>

<script>
import BaseActions from "../../store/BaseActions";
import { ControllerRoutes, SettingsRoutes } from "../../constraints/Routes";

export default {
  data() {
    return {
      settings: {},
      variant: 0,
      variants: [
        { key: 1, value: "Dark" },
        { key: 2, value: "White" },
        { key: 3, value: "Transparent" },
        { key: 4, value: "Primary" },
        { key: 5, value: "Secondary" },
        { key: 6, value: "Success" },
        { key: 7, value: "Danger" },
        { key: 8, value: "Warning" },
        { key: 9, value: "Info" },
      ],
      clientApps: [
        { key: 1, value: "Vue" },
        { key: 2, value: "Angular" },
        { key: 3, value: "React" },
      ],
    };
  },
  methods: {
    async initialize() {
      this.settings = await new BaseActions(ControllerRoutes.Settings).request(
        "GET",
        SettingsRoutes.Get()
      );
    },
    async onSubmit() {
      await new BaseActions(ControllerRoutes.Settings).update(this.settings);
      this.initialize();
    },
  },
  created() {
    this.initialize();
  },
};
</script>

<style scoped></style>
