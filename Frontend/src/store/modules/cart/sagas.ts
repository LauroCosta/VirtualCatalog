import { AxiosResponse } from 'axios';
import { all, takeLatest, select, call, put } from 'redux-saga/effects';
import { IState } from '../..';
import { ActionTypes } from './types';
import api from '../../../services/api';
import { addProductToCartSuccess, addProductToCartRequest, addProductToCartFailure } from './actions';

type CheckProductStockRequest = ReturnType<typeof addProductToCartRequest>;

interface IStockResponse {
  id: number;
  quantity: number;
}

function* checkProductStock({ payload }: CheckProductStockRequest) {
  const { product } = payload;

  const currentyQuantity: number = yield select((state: IState) => {
    return state.cart.items.find(item => item.product.id === product.id)?.quantity ?? 0;
  })

  const availableStockResponse: AxiosResponse<IStockResponse> = yield call(api.get, `stock/${product.id}`);

  if(availableStockResponse.data.quantity > currentyQuantity) {
    yield put(addProductToCartSuccess(product));
  }else{
    yield put(addProductToCartFailure(product.id));  
  }

  console.log(currentyQuantity);
}

export default all([
  takeLatest(ActionTypes.addProductToCartRequest, checkProductStock),
]);