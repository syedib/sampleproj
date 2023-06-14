export interface CreateProduct
{
  name: string;
  quanity: number;
  price: number;
  file: FormData
}

export interface Product
{
  id: string;
  name: string;
  description: string;
  quantity: string;
  price: string;
}
