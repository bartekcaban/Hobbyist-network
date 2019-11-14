<template>
  <v-dialog
    max-width="400"
    v-model="changePasswordDialog"
    persistent
  >
    <v-card>
      <v-card-title class="headline title">
        Zmień hasło
      </v-card-title>
      <v-card-text>
        <v-text-field
          label="Obecne hasło"
          type="password"
          v-model="currentPassword"
        ></v-text-field>
        <v-text-field
          label="Nowe Hasło"
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
          @click="save"
        >Zapisz
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'ChangePassword',
  data: () => ({
    password: '',
    currentPassword: '',
  }),
  props: {
    changePasswordDialog: Boolean,
  },
  methods: {
    ...mapActions(['changePassword']),
    async save() {
      await this.changePassword({ id: this.currentUser.id, password: this.password, currentPassword: this.currentPassword });
      this.close();
    },
    close() {
      this.currentPassword = '';
      this.password = '';
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
  background-color: $secondary;
}
</style>
