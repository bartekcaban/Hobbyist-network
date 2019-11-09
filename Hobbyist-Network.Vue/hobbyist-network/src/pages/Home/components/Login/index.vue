<template>
  <v-dialog
    max-width="400"
    v-model="loginDialog"
    persistent
  >
    <v-card>
      <v-card-title class="headline title">
        Zaloguj się
      </v-card-title>
      <v-card-text>
        <v-text-field
          label="Email"
          v-model="email"
        ></v-text-field>
        <v-text-field
          label="Hasło"
          type="password"
          v-model="password"
        ></v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="secondary"
          @click="close"
        >Anuluj
        </v-btn>
        <v-btn
          color="primary"
          @click="login"
        >Zaloguj się
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'Login',
  data: () => ({
    email: '',
    password: '',
  }),
  props: {
    loginDialog: Boolean,
  },
  methods: {
    ...mapActions(['loginUser']),
    async login() {
      await this.loginUser({ email: this.email, password: this.password });
      this.$router.push({
        name: 'Main',
      });
      this.$emit('close');
    },
    close() {
      this.$emit('close');
    },
  },
  computed: {
...mapGetters(['currentUser']),
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';

.title {
  color: white;
  background-color: $primary;
}
</style>
