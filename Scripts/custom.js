$(document).ready(function () {
    $("#CalculatePremium").click(function () {
        try {
            var plan = $('#PlanNumber').val();
            plan = parseInt(plan);
            var mode = $('#PremiumMode').val();
            var sumAssured = $('#SumAssured').val();
            sumAssured = parseInt(sumAssured);
            var term = $('#PolicyTerm').val();
            term = parseInt(term);
            var premiumMode = 0;
            var premiumAmount = 0.0;

            if (mode == "Monthly") {
                premiumMode = 1;
            } else if (mode == "Yearly") {
                premiumMode = 12;
            } else if (mode == "Quaterly") {
                premiumMode = 3;
            } else if (mode == "Half-Yearly") {
                premiumMode = 6;
            }

            if (plan == 1) {
                var total = (sumAssured / (term * 12)) * premiumMode;
                var bonus = total * .03;
                premiumAmount = total - bonus;
            } else if (plan == 2) {
                premiumAmount = (sumAssured / (term * 12)) * premiumMode;
            }
            $("#InstallementPremium").val(premiumAmount.toFixed(2));

        } catch (e) {
            throw e;
        }
    });
});
