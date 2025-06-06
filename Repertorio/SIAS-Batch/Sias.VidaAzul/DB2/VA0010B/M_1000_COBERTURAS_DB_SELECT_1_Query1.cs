using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_COBERTURAS_DB_SELECT_1_Query1 : QueryBasis<M_1000_COBERTURAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO,
            COD_OPERACAO,
            COD_MOEDA_PRM
            INTO :V1HSEG-DTMOVTO,
            :V1HSEG-CODOPER,
            :V1HSEG-CODMOEDA:V1HSEG-CODMOEDA-I
            FROM SEGUROS.V1HISTSEGVG
            WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE
            AND NUM_ITEM = :V1SEGV-ITEM
            AND OCORR_HISTORICO = :V1SEGV-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
							,
											COD_OPERACAO
							,
											COD_MOEDA_PRM
											FROM SEGUROS.V1HISTSEGVG
											WHERE NUM_APOLICE = '{this.V1SEGV_NUM_APOLICE}'
											AND NUM_ITEM = '{this.V1SEGV_ITEM}'
											AND OCORR_HISTORICO = '{this.V1SEGV_OCORHIST}'";

            return query;
        }
        public string V1HSEG_DTMOVTO { get; set; }
        public string V1HSEG_CODOPER { get; set; }
        public string V1HSEG_CODMOEDA { get; set; }
        public string V1HSEG_CODMOEDA_I { get; set; }
        public string V1SEGV_NUM_APOLICE { get; set; }
        public string V1SEGV_OCORHIST { get; set; }
        public string V1SEGV_ITEM { get; set; }

        public static M_1000_COBERTURAS_DB_SELECT_1_Query1 Execute(M_1000_COBERTURAS_DB_SELECT_1_Query1 m_1000_COBERTURAS_DB_SELECT_1_Query1)
        {
            var ths = m_1000_COBERTURAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_COBERTURAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_COBERTURAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1HSEG_DTMOVTO = result[i++].Value?.ToString();
            dta.V1HSEG_CODOPER = result[i++].Value?.ToString();
            dta.V1HSEG_CODMOEDA = result[i++].Value?.ToString();
            dta.V1HSEG_CODMOEDA_I = string.IsNullOrWhiteSpace(dta.V1HSEG_CODMOEDA) ? "-1" : "0";
            return dta;
        }

    }
}