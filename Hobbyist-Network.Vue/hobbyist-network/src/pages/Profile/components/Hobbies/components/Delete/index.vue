<template>
  <v-layout
      justify-center
      wrap
    >
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          color="secondary"
          icon
          text
          v-on="on"
        >
          <v-icon>mdi-delete</v-icon>
        </v-btn>
      </template>
      <v-card>
        <v-card-text>
          <v-row>
            <v-col class="text-center title">
              Czy na pewno chcesz usunąć to hobby?
            </v-col>
          </v-row>
        </v-card-text>
        <v-card-actions class="buttons">
          <v-btn
            color="secondary"
            @click="cancel"
          >
            Nie
          </v-btn>
          <v-btn
            color="primary"
            @click="deleteH"
          >
            Tak
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'AddHobby',
  data () {
    return {
      dialog: false,
    }
  },
  props: {
    hobby: null,
  },
  computed: {
    ...mapGetters(['currentUser']),
  },
  methods: {
    ...mapActions(['deleteHobby', 'getCurrentUser']),
    async deleteH() {
      await this.deleteHobby(this.hobby.id);
      await this.getCurrentUser(this.currentUser.id);
      this.cancel();
    },
    cancel() {
      this.dialog = false;
    },
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';

.title {
  margin-top: 20px;
  color: $secondary;
}
.buttons {
  display: flex;
  justify-content: space-between;
  margin-left: 20%;
  margin-right: 20%;
  margin-top: 20px;
  padding-bottom: 20px;
}
</style>