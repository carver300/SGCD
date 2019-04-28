<template>
    <v-container>
        
        <v-layout pt-3 justify-center>
            <h3>Citas del dia</h3>
        </v-layout>

        <v-layout >
            <v-flex>
                <v-progress-circular
                    :rotate="-90"
                    :size="150"
                    :width="5"
                    :value="75"
                    color="success"
                >
                    <h4>150</h4>
                </v-progress-circular>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
export default {
    name:'CitasDelDia',

}
</script>
