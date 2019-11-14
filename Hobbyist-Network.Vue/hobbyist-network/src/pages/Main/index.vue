<template>
  <div>
    <v-row>
      <v-col>
        <v-card class="card-left">
          <v-card-text>
            Osoby
          </v-card-text>
        </v-card>
      </v-col>
      <v-col>
        <v-card class="card-right">
          <v-card-text>
            Wydarzenia
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'Main',
  data: () => ({

  }),
  computed: {
    ...mapGetters(['currentUser']),
  },
  methods: {
    ...mapActions(['getUserDetails']),
  },
  async mounted() {
    await this.getUserDetails();
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';
.card-left {
  margin-left: 10px;
}
.card-right {
  margin-right: 10px;
}
</style>
