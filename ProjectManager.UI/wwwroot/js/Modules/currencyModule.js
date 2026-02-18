// wwwroot/js/modules/currencyModule.js

export const CurrencyModule = (function () {


    const culture = window.appCulture || "en-US";
    const decimalSeparator = window.appDecimalSeparator || ".";

    const numberFormatter = new Intl.NumberFormat(culture, {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });

    function parseVal($el) {
        const raw = $el.val().trim();

        if (!raw) return null;

        // Normalizacja: zamiana separatora kultury na kropkę
        const normalized = raw.replace(decimalSeparator, ".");

        const num = parseFloat(normalized);
        return isNaN(num) ? null : num;
    }

    function formatNumber(value) {
        return numberFormatter.format(value);
    }

    // ---------------------------------------
    // Conversions
    // ---------------------------------------

    function updatePlnFromEuro($eur, $rate, $pln) {
        const eur = parseVal($eur);
        const rate = parseVal($rate);

        if (eur !== null && rate !== null) {
            const pln = eur * rate;
            $pln.val(formatNumber(pln));
        }
    }

    function updateEuroFromPln($pln, $rate, $eur) {
        const pln = parseVal($pln);
        const rate = parseVal($rate);

        if (pln !== null && rate !== null && rate !== 0) {
            const eur = pln / rate;
            $eur.val(formatNumber(eur));
        }
    }

    // ---------------------------------------
    // Currency Switcher
    // ---------------------------------------

    function initCurrencySelector(container) {
        const $container = $(container);

        const $switcher = $container.find(".currency-switch");
        const $label = $container.find(".currency-label");
        const $plnFields = $container.find(".pln-fields");
        const $eurFields = $container.find(".euro-fields");

        $switcher.off("change").on("change", function () {
            const isEuro = $(this).is(":checked");

            if (isEuro) {
                $label.text("🇪🇺 EUR");
                $plnFields.slideUp();
                $eurFields.slideDown();
            } else {
                $label.text("🇵🇱 PLN");
                $eurFields.slideUp();
                $plnFields.slideDown();
            }
        });
    }

    // ---------------------------------------
    // Conversion Initializer
    // ---------------------------------------

    function initConversion(config) {
        const $pln = $(config.plnSelector);
        const $eur = $(config.eurSelector);
        const $rate = $(config.rateSelector);

        // EUR → PLN
        $(document).on("input", config.eurSelector, function () {
            updatePlnFromEuro($eur, $rate, $pln);
        });

        // PLN → EUR
        $(document).on("input", config.plnSelector, function () {
            updateEuroFromPln($pln, $rate, $eur);
        });

        // Kurs → przelicz w obie strony
        $(document).on("input", config.rateSelector, function () {
            updatePlnFromEuro($eur, $rate, $pln);
            updateEuroFromPln($pln, $rate, $eur);
        });
    }

    // ---------------------------------------
    // Public API
    // ---------------------------------------

    return {
        initCurrencySelector,
        initConversion
    };

})();
