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
    public class DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1 : QueryBasis<DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :VGTERNIV-QTD-VIDAS
            FROM SEGUROS.VG_MOV_FUNCIONARIO
            WHERE NUM_PROPOSTA_SIVPF = :VGMOVFUN-NUM-PROPOSTA-SIVPF
            AND DTH_INI_VIGENCIA <= :VGMOVFUN-DTH-INI-VIGENCIA
            AND DTH_FIM_VIGENCIA >= :VGMOVFUN-DTH-INI-VIGENCIA
            AND NUM_NIVEL_CARGO = :VGMOVFUN-NUM-NIVEL-CARGO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.VG_MOV_FUNCIONARIO
											WHERE NUM_PROPOSTA_SIVPF = '{this.VGMOVFUN_NUM_PROPOSTA_SIVPF}'
											AND DTH_INI_VIGENCIA <= '{this.VGMOVFUN_DTH_INI_VIGENCIA}'
											AND DTH_FIM_VIGENCIA >= '{this.VGMOVFUN_DTH_INI_VIGENCIA}'
											AND NUM_NIVEL_CARGO = '{this.VGMOVFUN_NUM_NIVEL_CARGO}'";

            return query;
        }
        public string VGTERNIV_QTD_VIDAS { get; set; }
        public string VGMOVFUN_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGMOVFUN_DTH_INI_VIGENCIA { get; set; }
        public string VGMOVFUN_NUM_NIVEL_CARGO { get; set; }

        public static DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1 Execute(DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1 dB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1)
        {
            var ths = dB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB078_ACESSA_VGMOVFUNCIONARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGTERNIV_QTD_VIDAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}