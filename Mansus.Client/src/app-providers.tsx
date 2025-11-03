import React from "react";

const providers_arr = [];

function Providers({ children }) {
	return providers_arr.reduceRight((acc, Provider) => {
		return <Provider>{acc}</Provider>;
	}, children);
}

export default Providers;
