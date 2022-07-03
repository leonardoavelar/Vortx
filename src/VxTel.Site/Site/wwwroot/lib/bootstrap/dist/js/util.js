{
    function mask(o, f) {
        v_obj = o
        v_fun = f
        setTimeout('execmascara()', 1)
    }

    function execmascara() {
        v_obj.value = v_fun(v_obj.value)
    }

    function maskHoraMinutoSegundo(v) {
        v = v.replace(/(\d{2})(\d)/, "$1:$2")
        v = v.replace(/(\d{2})(\d)/, "$1:$2")
        v = v.replace(/(\d{2})(\d)/, "$1:$2")

        return v
    }

    function maskCpfCnpj(v) {

        v = v.replace(/\D/g, "")
        v = v.substring(0, 14);

        // CPF
        if (v.length <= 11) {
            v = v.replace(/(\d{3})(\d)/, "$1.$2")
            v = v.replace(/(\d{3})(\d)/, "$1.$2")
            v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
        }
        // CNPJ
        else {
            v = v.replace(/(\d{2})(\d)/, "$1.$2")
            v = v.replace(/(\d{3})(\d)/, "$1.$2")
            v = v.replace(/(\d{3})(\d)/, "$1/$2")
            v = v.replace(/(\d{4})(\d{1,2})$/, "$1-$2")
        }

        return v
    }

    function maskTelDdi(v) {

        // DDI
        v = v.replace(/\D/g, "")
        v = v.substring(0, 3);

        //if (v.length <= 1) {
        //    v = v.replace(/(\d{1})/, "+$1")
        //}
        //else if (v.length <= 2) {
        //    v = v.replace(/(\d{2})/, "+$1")
        //}
        //else {
        //    v = v.replace(/(\d{3})/, "+$1")
        //}            
        return v
    }

    function maskTelDdd(v) {

        // DDD
        v = v.replace(/\D/g, "")
        v = v.substring(0, 3);

        //if (v.length <= 1) {
        //    v = v.replace(/(\d{1})/, "($1)")
        //}
        //else if (v.length <= 2) {
        //    v = v.replace(/(\d{2})/, "($1)")
        //}
        //else {
        //    v = v.replace(/(\d{3})/, "($1)")
        //}
        return v
    }

    function maskTel(v) {

        v = v.replace(/\D/g, "")
        v = v.substring(0, 9);

        // Telefone
        if (v.length <= 8) {
            v = v.replace(/(\d{4})(\d)/, "$1-$2")
        }
        // Celular
        else {
            v = v.replace(/(\d{5})(\d)/, "$1-$2")
        }

        return v
    }

    function maskCep(v) {

        // CEP
        v = v.replace(/\D/g, "")
        v = v.substring(0, 8);

        v = v.replace(/(\d{2})(\d)/, "$1.$2")
        v = v.replace(/(\d{3})(\d)/, "$1-$2")

        return v
    }

    function maskNroSize10(v) {

        v = v.replace(/\D/g, "")
        v = v.substring(0, 10);

        return v
    }
};