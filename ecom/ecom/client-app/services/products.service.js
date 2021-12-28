import Vue from 'vue'
import axios from 'axios'

const client = axios.create({
    baseURL: 'http://localhost:5000/api/products',
    json: true
})

export default {
    async execute(method, resource, data) {
        
        return client({
            method,
            url: resource,
            data,
            headers: {
               
            }
        }).then(req => {
            return req.data
        })
    },
    getAll() {
        return this.execute('get', '/')
    },
    getByName(name) {
        return this.execute('get', `/${name}`)
    },
    create(data) {
        return this.execute('post', '/', data)
    },
    update(id, data) {
        return this.execute('put', `/${id}`, data)
    },
}