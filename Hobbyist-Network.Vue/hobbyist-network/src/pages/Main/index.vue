<template>
  <div>
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

</style>
