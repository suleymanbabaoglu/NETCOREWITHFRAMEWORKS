<template>
  <div class="row justify-content-center" style="margin-top: 5%">
    <div class="col-xs-6 col-sm-6 col-md-6 col-lg-3">
      <b-card
        style="max-width: 100%;background-color: darkseagreen"
        class="mb-2"
      >
        <b-card-header>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            viewBox="-1350 50 4000 1200"
            version="1.1"
            class="bv-logo"
          >
            <defs>
              <filter
                id="logo-shadow"
                filterUnits="objectBoundingBox"
                x="-50%"
                y="-50%"
                width="200%"
                height="200%"
              >
                <feOffset
                  in="SourceAlpha"
                  dx="-10"
                  dy="25"
                  result="ALPHA1"
                ></feOffset>
                <feMorphology
                  in="ALPHA1"
                  operator="dilate"
                  radius="15"
                  result="ALPHA"
                ></feMorphology>
                <feGaussianBlur
                  in="ALPHA"
                  stdDeviation="20"
                  result="DROP"
                ></feGaussianBlur>
                <feFlood in="DROP" flood-color="#333" result="SOLID"></feFlood>
                <feComposite
                  in="DROP"
                  in2="SOLID"
                  operator="in"
                  result="SHADOW1"
                ></feComposite>
                <feComponentTransfer in="SHADOW1" result="SHADOW">
                  <feFuncA type="linear" slope="0.55"></feFuncA>
                </feComponentTransfer>
                <feMerge>
                  <feMergeNode in="SHADOW"></feMergeNode>
                  <feMergeNode in="SourceGraphic"></feMergeNode>
                </feMerge>
              </filter>
            </defs>
            <g>
              <g filter="url(#logo-shadow)" class="logo-dark-v">
                <path
                  fill="#34495E"
                  d="M747 311L602 562 458 311H227l375 651 376-651z"
                ></path>
              </g>
              <g filter="url(#logo-shadow)" class="logo-purple-v">
                <path
                  fill="#563D7C"
                  fill-rule="nonzero"
                  d="M219 195h762L599 857z"
                ></path>
                <path
                  fill="#ffffff"
                  d="M501 282l132 0c25,0 44,5 59,16 15,12 22,28 22,51 0,14 -3,26 -10,35 -7,10 -16,18 -29,23l0 1c17,3 30,11 38,24 9,12 13,27 13,46 0,11 -2,21 -6,30 -3,9 -9,17 -17,24 -9,6 -19,12 -32,16 -12,4 -28,6 -45,6l-125 0 0 -272 0 0zm48 114l77 0c12,0 21,-4 29,-10 8,-7 11,-16 11,-28 0,-14 -3,-24 -10,-29 -7,-6 -17,-9 -30,-9l-77 0 0 76 0 0zm0 119l84 0c14,0 26,-4 33,-11 8,-8 13,-19 13,-32 0,-14 -4,-24 -13,-31 -8,-8 -19,-11 -33,-11l-84 0 0 85z"
                  class="logo-white-b"
                ></path>
              </g>
              <g filter="url(#logo-shadow)" class="logo-green-v">
                <path
                  fill="#41B883"
                  d="M839 357L600 771 361 357H202l398 690 398-690z"
                ></path>
              </g>
            </g>
          </svg>
        </b-card-header>
        <b-card-text>
          <b-form @submit.prevent="onSubmit">
            <b-form-group>
              <b-form-input
                v-model="form.email"
                type="email"
                required
                placeholder="Enter E-mail"
              />
            </b-form-group>

            <b-form-group>
              <b-form-input
                id="input-2"
                v-model="form.password"
                type="password"
                required
                placeholder="Enter Password"
              ></b-form-input>
            </b-form-group>
            <b-form-group class="text-center">
              <b-button
                type="submit"
                variant="success"
                class="mt-3"
                style="width: 80%"
                >Login</b-button
              >
              <router-link to="register">
                <b-button variant="primary" class="mt-3" style="width: 80%"
                  >Register</b-button
                >
              </router-link>
            </b-form-group>
          </b-form>
        </b-card-text>
      </b-card>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      form: {
        email: "",
        password: ""
      }
    };
  },
  methods: {
    onSubmit() {
      alert(JSON.stringify(this.form));
    }
  }
};
</script>

<style scoped></style>
