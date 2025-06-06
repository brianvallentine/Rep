using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_HISTORICO),0)
            INTO :HISTSG-OCORHIST
            FROM SEGUROS.V0HISTSEGVG
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND NUM_ITEM = :SEGURA-NUM-ITEM
            AND COD_OPERACAO IN (796, 896)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_HISTORICO)
							,0)
											FROM SEGUROS.V0HISTSEGVG
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURA_NUM_ITEM}'
											AND COD_OPERACAO IN (796
							, 896)";

            return query;
        }
        public string HISTSG_OCORHIST { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string SEGURA_NUM_ITEM { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1();
            var i = 0;
            dta.HISTSG_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}