<template>
    <div class="hello">
        <h3>Weather Forecast</h3>
        <ul>
            <li v-for="i in weather" :key="i">{{i}}</li>
        </ul>
    </div>
</template>

<script>
    import axios from 'axios'

    const client = axios.create({
        baseURL: 'http://localhost:5000',
        json: true
    });

    export default {
        data() {
            return {
                weather: []
            }
        },
        async created() {
            let data = await client.get('/weatherforecast')
            this.weather = data.data
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
