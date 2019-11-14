<template>
  <div>
    <v-row>
      <v-col>
        <v-row>
          <v-col>
        <v-select
          label="Kategoria"
        >
        </v-select>
          </v-col>
          <v-col>
        <v-select
          label="Poziom"
        >
        </v-select>
          </v-col>
          <v-col cols="2">
            <v-btn
              color="primary"
            >Dodaj
            </v-btn>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-chip class="hobby">
          <v-icon left>mdi-gamepad-variant</v-icon>
          Koszykówka
        </v-chip>
        <v-chip class="hobby">
          <v-icon left>mdi-gamepad-variant</v-icon>
          Szachy
        </v-chip>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {
  name: 'Hobbies',
  data () {
    return {
    }
  },
}
</script>

<style lang="scss" scoped>
.hobby {
  margin-right: 10px;
}
</style>