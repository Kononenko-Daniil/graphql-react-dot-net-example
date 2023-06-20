import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { ApolloProvider, ApolloClient, InMemoryCache, createHttpLink } from "@apollo/client";
import { setContext } from '@apollo/client/link/context';
import keycloak from './keycloak';

const httpLink = createHttpLink({ uri: 'https://localhost:7155/graphql/' });

const authLink = setContext((_, { headers }) => {
	return {
		headers: {
		...headers,
		authorization: keycloak.token ? `Bearer ${keycloak.token}` : "",
		}
	}
});

const client = new ApolloClient({
	link: authLink.concat(httpLink),
	cache: new InMemoryCache()
});

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
	<ApolloProvider client={client}>
		<App />
	</ApolloProvider>
);

reportWebVitals();
