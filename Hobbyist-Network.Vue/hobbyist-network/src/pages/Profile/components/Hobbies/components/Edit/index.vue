<template>
  <div class="text-center">
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          color="primary"
          icon
          text
          v-on="on"
        >
          <v-icon>mdi-pencil</v-icon>
        </v-btn>
      </template>
      <v-card>
        <v-card-title class="headline title">
          Edytuj hobby
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col>
              <v-select
                :items="hobbyCategories"
                item-value="id"
                item-text="name"
                label="Kategoria"
                v-model="hobby.categoryId"
                >
              </v-select>
              </v-col>
              <v-col>
              <v-select
                label="Poziom"
                :items="levels"
                v-model="hobby.level"
                >
              </v-select>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <v-textarea
                v-model="hobby.description"
                label="Opis"
                counter="30"
              ></v-textarea>
            </v-col>
          </v-row>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="secondary"
            @click="cancel"
          >
            Anuluj
          </v-btn>
          <v-btn
            color="primary"
            @click="edit"
            :disabled="!hobby.categoryId || !hobby.level"
          >
            Zapisz
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

import { LEVELS } from '@/shared/constants';

export default {
  name: 'EditHobby',
  data () {
    return {
      dialog: false,
      levels: LEVELS,
    }
  },
  props: {
    hobby: null,
  },
  computed: {
    ...mapGetters(['hobbyCategories', 'currentUser']),
  },
  methods: {
    ...mapActions(['editHobby', 'getCurrentUser']),
    async edit() {
      await this.editHobby(this.hobby);
      await this.getCurrentUser(this.currentUser.id);
      this.cancel();
    },
    async cancel() {
      await this.getCurrentUser(this.currentUser.id);
      this.dialog = false;
    },
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