QUnit.config.autostart = false;

sap.ui.require([
	"sap/ui/core/Core",
	"ui5/coders/test/integration/AllJourneys"
], async (Core) => {
	"use strict";

	await Core.ready();

	sap.ui.require([
		"ui5/coders/test/integration/AllJourneys"
	], () => {
		QUnit.start();
	});
});