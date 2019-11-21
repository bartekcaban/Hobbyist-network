<template>
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
              Czy na pewno chcesz usunąć to wydarzenie?
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
            @click="deleteE"
          >
            Tak
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'DeleteEvent',
  data () {
    return {
      dialog: false,
    }
  },
  props: {
    event: Object,
  },
  methods: {
    ...mapActions(['deleteEvent', 'getEvents']),
    async deleteE() {
      await this.deleteEvent(this.event.id);
      await this.getEvents();
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