let jwtToken = null;

// --- PREKOMPILACJA TAGÓW ---

const headers = [
    { name: "P196" },
    { name: "P302" },
    { name: "T208" },
    { name: "L234" },
    { name: "P145" },
    { name: "P270" },
    { name: "UAKUM" },
    { name: "P371" },
    { name: "T203" },
    { name: "T377" },
    { name: "T201" },
    { name: "T378" },
    { name: "P232" },
    { name: "E149" },
    { name: "G197" },
    { name: "S200" },
    { name: "E198.2" },
    { name: "E198.6" },
    { name: "E199.7" },
    { name: "T288" },
    { name: "T206" },
    { name: "T207" },
    { name: "P268" },
    { name: "T202" },
    { name: "T405" },
    { name: "T419" },
    { name: "T291" },
    { name: "T289" },
    { name: "T384" },
    { name: "T290" },
    { name: "T385" },
    { name: "T459" },
    { name: "T460" },
    { name: "T209" },
    { name: "T210" },
    { name: "T211" },
    { name: "T461" },
    { name: "T462" },
    { name: "T463" },
    { name: "T464" },
    { name: "T465" },
    { name: "T466" },
    { name: "T467" },
    { name: "T468" },
    { name: "T469" },
    { name: "T470" },
    { name: "T471" },
    { name: "T472" },
    { name: "T473" },
    { name: "T474" },
    { name: "T475" },
    { name: "T476" },
    { name: "T477" },
    { name: "T478" },
    { name: "T479" },
    { name: "T480" },
    { name: "T501" },
    { name: "T494" },
    { name: "T495" },
    { name: "S492" },
    { name: "S493" },
    { name: "P497" },
    { name: "P318" },
    { name: "G273" },
    { name: "GKS" },
    { name: "NKS" },
    { name: "FGEN" },
    { name: "PGEN" },
    { name: "QGEN" },
    { name: "PF" },
    { name: "UL12G" },
    { name: "UL23G" },
    { name: "UL31G" },
    { name: "UL1G" },
    { name: "UL2G" },
    { name: "UL2G" },
    { name: "IL1G" },
    { name: "IL2G" },
    { name: "IL3G" },
    { name: "FM" },
    { name: "UL12M" },
    { name: "UL23M" },
    { name: "UL31M" },
    { name: "UL1M" },
    { name: "UL2M" },
    { name: "UL3M" },
    { name: "PSET" },
    { name: "PFSET" },
    { name: "PSCADA" },
    { name: "PFSCADA" },
    { name: "POSD" },
    { name: "QOSD" },
    { name: "PFOSD" },
    { name: "UOSD" },
    { name: "T290" },
    { name: "T385" },
];

// Prekompilowane funkcje odczytu wartości
const readers = [
    () => Globals.Tags.GetTag("P196").Read(),
    () => Globals.Tags.GetTag("P302").Read(),
    () => Globals.Tags.GetTag("T208").Read(),
    () => Globals.Tags.GetTag("L234").Read(),
    () => Globals.Tags.GetTag("P145").Read(),
    () => Globals.Tags.GetTag("P270").Read(),
    () => Globals.Tags.GetTag("UAKUM").Read(),
    () => Globals.Tags.GetTag("P371").Read(),
    () => Globals.Tags.GetTag("T203").Read(),
    () => Globals.Tags.GetTag("T377").Read(),
    () => Globals.Tags.GetTag("T201").Read(),
    () => Globals.Tags.GetTag("T378").Read(),
    () => Globals.Tags.GetTag("P232").Read(),
    () => Globals.Tags.GetTag("E149").Read(),
    () => Globals.Tags.GetTag("G197").Read(),
    () => Globals.Tags.GetTag("S200").Read(),
    () => Globals.Tags.GetTag("E198.2").Read(),
    () => Globals.Tags.GetTag("E198.6").Read(),
    () => Globals.Tags.GetTag("E199.7").Read(),
    () => Globals.Tags.GetTag("T288").Read(),
    () => Globals.Tags.GetTag("T206").Read(),
    () => Globals.Tags.GetTag("T207").Read(),
    () => Globals.Tags.GetTag("P268").Read(),
    () => Globals.Tags.GetTag("T202").Read(),
    () => Globals.Tags.GetTag("T405").Read(),
    () => Globals.Tags.GetTag("T419").Read(),
    () => Globals.Tags.GetTag("T291").Read(),
    () => Globals.Tags.GetTag("T289").Read(),
    () => Globals.Tags.GetTag("T384").Read(),
    () => Globals.Tags.GetTag("T290").Read(),
    () => Globals.Tags.GetTag("T385").Read(),
    () => Globals.Tags.GetTag("T459").Read(),
    () => Globals.Tags.GetTag("T460").Read(),
    () => Globals.Tags.GetTag("T209").Read(),
    () => Globals.Tags.GetTag("T210").Read(),
    () => Globals.Tags.GetTag("T211").Read(),
    () => Globals.Tags.GetTag("T461").Read(),
    () => Globals.Tags.GetTag("T462").Read(),
    () => Globals.Tags.GetTag("T463").Read(),
    () => Globals.Tags.GetTag("T464").Read(),
    () => Globals.Tags.GetTag("T465").Read(),
    () => Globals.Tags.GetTag("T466").Read(),
    () => Globals.Tags.GetTag("T467").Read(),
    () => Globals.Tags.GetTag("T468").Read(),
    () => Globals.Tags.GetTag("T469").Read(),
    () => Globals.Tags.GetTag("T470").Read(),
    () => Globals.Tags.GetTag("T471").Read(),
    () => Globals.Tags.GetTag("T472").Read(),
    () => Globals.Tags.GetTag("T473").Read(),
    () => Globals.Tags.GetTag("T474").Read(),
    () => Globals.Tags.GetTag("T475").Read(),
    () => Globals.Tags.GetTag("T476").Read(),
    () => Globals.Tags.GetTag("T477").Read(),
    () => Globals.Tags.GetTag("T478").Read(),
    () => Globals.Tags.GetTag("T479").Read(),
    () => Globals.Tags.GetTag("T480").Read(),
    () => Globals.Tags.GetTag("T501").Read(),
    () => Globals.Tags.GetTag("T494").Read(),
    () => Globals.Tags.GetTag("T495").Read(),
    () => Globals.Tags.GetTag("S492").Read(),
    () => Globals.Tags.GetTag("S493").Read(),
    () => Globals.Tags.GetTag("P497").Read(),
    () => Globals.Tags.GetTag("P318").Read(),
    () => Globals.Tags.GetTag("G273").Read(),
    () => Globals.Tags.GetTag("GKS").Read(),
    () => Globals.Tags.GetTag("NKS").Read(),
    () => Globals.Tags.GetTag("FGEN").Read(),
    () => Globals.Tags.GetTag("PGEN").Read(),
    () => Globals.Tags.GetTag("QGEN").Read(),
    () => Globals.Tags.GetTag("PF").Read(),
    () => Globals.Tags.GetTag("UL12G").Read(),
    () => Globals.Tags.GetTag("UL23G").Read(),
    () => Globals.Tags.GetTag("UL31G").Read(),
    () => Globals.Tags.GetTag("UL1G").Read(),
    () => Globals.Tags.GetTag("UL2G").Read(),
    () => Globals.Tags.GetTag("UL2G").Read(),
    () => Globals.Tags.GetTag("IL1G").Read(),
    () => Globals.Tags.GetTag("IL2G").Read(),
    () => Globals.Tags.GetTag("IL3G").Read(),
    () => Globals.Tags.GetTag("FM").Read(),
    () => Globals.Tags.GetTag("UL12M").Read(),
    () => Globals.Tags.GetTag("UL23M").Read(),
    () => Globals.Tags.GetTag("UL31M").Read(),
    () => Globals.Tags.GetTag("UL1M").Read(),
    () => Globals.Tags.GetTag("UL2M").Read(),
    () => Globals.Tags.GetTag("UL3M").Read(),
    () => Globals.Tags.GetTag("PSET").Read(),
    () => Globals.Tags.GetTag("PFSET").Read(),
    () => Globals.Tags.GetTag("PSCADA").Read(),
    () => Globals.Tags.GetTag("PFSCADA").Read(),
    () => Globals.Tags.GetTag("POSD").Read(),
    () => Globals.Tags.GetTag("QOSD").Read(),
    () => Globals.Tags.GetTag("PFOSD").Read(),
    () => Globals.Tags.GetTag("UOSD").Read(),
    () => Globals.Tags.GetTag("T290").Read(),
    () => Globals.Tags.GetTag("T385").Read(),
];

// Prealokowana tablica DTO
const dtoArray = new Array(headers.length);
for (let i = 0; i < headers.length; i++) {
    dtoArray[i] = {
        timeStamp: "",
        name: headers[i].name,
        value: 0
    };
}

// --- AUTORYZACJA ---

function authenticate() {
    var req = HMIRuntime.HttpRequest("https://localhost:7245/api/tokens");

    req.Method = "POST";
    req.SetHeader("Content-Type", "application/json");

    var body = JSON.stringify({
        userName: "dako@eneria.pl",
        password: "AQAAAAEAACcQAAAAEFG6mYrUpDiYNa7d0bGK1yF/98FFDYNNI6G/bE/sR3PmgvuXpAKldAy+wOYbAwPkjg=="
    });

    req.Send(body);

    var resp = req.GetResponseString();
    if (!resp) {
        HMIRuntime.Trace("Auth error: empty response");
        return;
    }

    try {
        var data = JSON.parse(resp);
        jwtToken = data.token;
    } catch (e) {
        HMIRuntime.Trace("Auth parse error: " + e);
    }
}

// --- WYSYŁANIE PARAMETRÓW ---

function sendParams() {

    if (!jwtToken) {
        authenticate();
        if (!jwtToken) {
            HMIRuntime.Trace("Auth failed, skipping send");
            return;
        }
    }

    var now = new Date().toISOString();

    // Wypełnianie DTO
    for (let i = 0; i < dtoArray.length; i++) {
        dtoArray[i].timeStamp = now;
        dtoArray[i].value = readers[i]();
    }

    var payload = {
        deviceId: 1,
        deviceParams: dtoArray
    };

    var req = HMIRuntime.HttpRequest("https://localhost:7245/api/telemetries/params");
    req.Method = "POST";
    req.SetHeader("Content-Type", "application/json");
    req.SetHeader("Authorization", "Bearer " + jwtToken);

    var json = JSON.stringify(payload);

    req.Send(json);

    var resp = req.GetResponseString();
    if (!resp) {
        HMIRuntime.Trace("Send error: empty response");
    }
}

// --- INTERWAŁ ---

HMIRuntime.SetInterval(sendParams, 60000);
