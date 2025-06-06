using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1 : QueryBasis<DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VLR_PREMIO),0)
            INTO :VGFUNCOB-VLR-PREMIO
            FROM SEGUROS.VG_FUNC_COBERTURA
            WHERE NUM_PROPOSTA_SIVPF
            = :VGMOVFUN-NUM-PROPOSTA-SIVPF
            AND DTH_INI_VIGENCIA = :VGMOVFUN-DTH-INI-VIGENCIA
            AND NUM_CPF = :VGMOVFUN-NUM-CPF
            AND COD_GARANTIA = 17
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VLR_PREMIO)
							,0)
											FROM SEGUROS.VG_FUNC_COBERTURA
											WHERE NUM_PROPOSTA_SIVPF
											= '{this.VGMOVFUN_NUM_PROPOSTA_SIVPF}'
											AND DTH_INI_VIGENCIA = '{this.VGMOVFUN_DTH_INI_VIGENCIA}'
											AND NUM_CPF = '{this.VGMOVFUN_NUM_CPF}'
											AND COD_GARANTIA = 17";

            return query;
        }
        public string VGFUNCOB_VLR_PREMIO { get; set; }
        public string VGMOVFUN_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGMOVFUN_DTH_INI_VIGENCIA { get; set; }
        public string VGMOVFUN_NUM_CPF { get; set; }

        public static DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1 Execute(DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1 dB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1)
        {
            var ths = dB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB084_ACESSA_VG_FUNC_COBERTURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGFUNCOB_VLR_PREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}