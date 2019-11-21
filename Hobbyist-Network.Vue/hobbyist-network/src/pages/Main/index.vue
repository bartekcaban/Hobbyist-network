<template>
  <div>
    <v-row>
      <v-col>
        <v-hover>
          <template v-slot:default="{ hover }">
            <v-card class="card-left">
              <v-img src="@/assets/youth.jpg"></v-img>
              <v-card-text>
                <h2 class="title secondary--text">Ludzie</h2>
                Poznaj ludzi o podobnych zainteresowaniach!
              </v-card-text>
              <v-fade-transition>
                <v-overlay
                  v-if="hover"
                  absolute
                  color="primary"
                >
                  <v-btn color="secondary" @click="goToPeople">Przejdź</v-btn>
                </v-overlay>
              </v-fade-transition>
            </v-card>
          </template>
        </v-hover>
      </v-col>
      <v-col>
        <v-hover>
          <template v-slot:default="{ hover }">
            <v-card class="card-right">
              <v-img src="@/assets/audience.jpg"></v-img>
              <v-card-text>
                <h2 class="title secondary--text">Wydarzenia</h2>
                Twórz i bierz udział w interesujących Cię wydarzeniach!
              </v-card-text>
              <v-fade-transition>
                <v-overlay
                  v-if="hover"
                  absolute
                  color="primary"
                >
                  <v-btn color="secondary" @click="goToEvents">Przejdź</v-btn>
                </v-overlay>
              </v-fade-transition>
            </v-card>
          </template>
        </v-hover>
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
    goToPeople() {
      this.$router.push({
          name: 'People',
        });
    },
    goToEvents() {
      this.$router.push({
          name: 'Events',
        });
    },
  },
  async mounted() {
    await this.getUserDetails();
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';

.card-left {
  margin-left: 20px;
  width: 45rem;
}
.card-right {
  width: 45rem;
}
</style>
