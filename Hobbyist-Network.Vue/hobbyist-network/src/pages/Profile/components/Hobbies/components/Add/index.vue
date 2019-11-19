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
          <v-icon>mdi-plus-thick</v-icon>
        </v-btn>
      </template>
      <v-card>
        <v-card-title class="headline title">
          Dodaj nowe hobby
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col>
              <v-select
                :items="hobbyCategories"
                item-value="id"
                item-text="name"
                label="Kategoria"
                v-model="categoryId"
                >
              </v-select>
              </v-col>
              <v-col>
              <v-select
                label="Poziom"
                :items="levels"
                v-model="level"
                >
              </v-select>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <v-textarea
                v-model="description"
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
            @click="add"
            :disabled="!categoryId || !level"
          >
            Dodaj
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
  name: 'AddHobby',
  data () {
    return {
      dialog: false,
      levels: LEVELS,
      categoryId: null,
      level: null,
      description: null,
    }
  },
  computed: {
    ...mapGetters(['hobbyCategories', 'currentUser']),
  },
  methods: {
    ...mapActions(['addHobby', 'getCurrentUser']),
    async add() {
      await this.addHobby({
        categoryId: this.categoryId,
        level: this.level,
        userId: this.currentUser.id,
        description: this.description,
      });
      await this.getCurrentUser(this.currentUser.id);
      this.cancel();
    },
    cancel() {
      this.dialog = false;
      this.description = null;
      this.categoryId = null;
      this.level = null;
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