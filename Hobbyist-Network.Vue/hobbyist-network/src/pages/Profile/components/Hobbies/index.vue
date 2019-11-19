<template>
  <div>
    <v-row>
      <v-col>
        <v-data-table
          :headers="headers"
          :items="currentUser.hobbies"
          disable-sort
          hide-default-footer
          fixed-header
        >
        <template v-slot:top>
          <v-toolbar flat color="white">
            <v-toolbar-title>Moje hobby</v-toolbar-title>
            <v-spacer></v-spacer>
            <Add/>
          </v-toolbar>
        </template>
        <template v-slot:item.level="{ item }">
          {{ getLevelName(item.level) }}
        </template>
        <template v-slot:item.action="{ item }">
          <v-row>
            <Edit :hobby="item"/>
            <Delete :hobby="item"/>
          </v-row>
        </template>
      </v-data-table>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

import { LEVELS, levelName } from '@/shared/constants';

import { HEADERS } from './constants';
import Add from './components/Add';
import Edit from './components/Edit';
import Delete from './components/Delete';

export default {
  name: 'Hobbies',
  data () {
    return {
      levels: LEVELS,
      categoryId: null,
      level: null,
      description: null,
      headers: HEADERS,
    }
  },
  components: {
    Add,
    Edit,
    Delete,
  },
  computed: {
    ...mapGetters(['hobbyCategories', 'currentUser']),
  },
  methods: {
    ...mapActions(['getHobbyCategories']),
    getLevelName: levelName,
  },
  async created() {
    await this.getHobbyCategories();
  },
}
</script>

<style lang="scss" scoped>
.hobby {
  margin-right: 10px;
}
</style>