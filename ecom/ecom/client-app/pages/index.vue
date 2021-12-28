<template>
  <div class="container">
    <CBox mt="10" py="4" px="2" mx="2" border="1px" bordercolor="gray.200">
      <CInput placeholder="Search by Product name" v-model="filter" @change="onFilterChange" />
    </CBox>
    <CBox mt="2" px="2" mx="2" border="1px" bordercolor="gray.200">
      <CSimpleGrid minChildWidth="120px" spacing="40px">
        <CBox  v-for="product in products" :key="product.id">
          <CImage
            boxSize="100px"
            objectFit="cover"
            :src="`/images/${product.image}`"
          />
         
          <CBox>{{ product.name }}</CBox>
          <CBox>รายละเอียด {{ product.description }}</CBox>
          <CBox>{{ product.price }}$</CBox>
        </CBox>
      </CSimpleGrid>
    </CBox>
  </div>
</template>

<script lang="js">
import {
  CBox,
  CButton,
  CAvatarGroup,
  CAvatar,
  CAvatarBadge,
  CModal,
  CModalContent,
  CModalOverlay,
  CModalHeader,
  CModalFooter,
  CModalBody,
  CModalCloseButton,
  CIconButton,
  CFlex,
  CHeading,
  CSimpleGrid,
  CInput,
  CVStack,
  CImage,
} from '@chakra-ui/vue'

import Tutorial from '../components/Tutorial.vue'
import api from '@/services/products.service';
export default {
  name: 'IndexPage',
  components: {
    CBox,
    CButton,
    CAvatarGroup,
    CAvatar,
    CAvatarBadge,
    CModal,
    CModalContent,
    CModalOverlay,
    CModalHeader,
    CModalFooter,
    CModalBody,
    CModalCloseButton,
    CIconButton,
    CFlex,
    CHeading,
    CSimpleGrid,
    CInput,
    CVStack,
    CImage
  },

  data() {
    return {
      
      filter: '',
      products: []
    }
  },
  async created() {
    this.products = await api.getAll();

  },
  
  methods: {
    
    async onFilterChange(e) {
      e.preventDefault();
      this.products = await api.getByName(this.filter);


    }
  }
}
</script>
