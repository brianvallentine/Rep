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
    public class DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1 : QueryBasis<DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T2.COD_CORRESP_BANC
            INTO :PROPSSVD-COD-CORRESP-BANC
            FROM SEGUROS.PROPOSTA_FIDELIZ T1,
            SEGUROS.PROP_SASSE_VIDA T2
            WHERE T1.NUM_PROPOSTA_SIVPF =
            :PROPOFID-NUM-PROPOSTA-SIVPF
            AND T1.NUM_IDENTIFICACAO = T2.NUM_IDENTIFICACAO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT T2.COD_CORRESP_BANC
											FROM SEGUROS.PROPOSTA_FIDELIZ T1
							,
											SEGUROS.PROP_SASSE_VIDA T2
											WHERE T1.NUM_PROPOSTA_SIVPF =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											AND T1.NUM_IDENTIFICACAO = T2.NUM_IDENTIFICACAO
											WITH UR";

            return query;
        }
        public string PROPSSVD_COD_CORRESP_BANC { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1 Execute(DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1 dB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1)
        {
            var ths = dB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB134_ACESSA_PROPFID_PSASSEV_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPSSVD_COD_CORRESP_BANC = result[i++].Value?.ToString();
            return dta;
        }

    }
}