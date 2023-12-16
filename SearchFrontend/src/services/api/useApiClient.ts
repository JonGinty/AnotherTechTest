import axios from 'axios'
import { useMemo } from 'react'

/*
 * note that this is the local dev server for react. We're
 * using the proxy setting in package.json to proxy any unknown
 * requests (i.e. requests to the .net API) to the api host.
 */
const baseURL = 'http://localhost:3000/'

export default function useApiClient () {
  return useMemo(() => {
    const client = axios.create({ baseURL })
    // todo: error interceptor?
    return client
  }, [baseURL])
}
