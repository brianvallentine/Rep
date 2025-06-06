using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1 : QueryBasis<M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_BENEFICIARIO),0)
            INTO :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO
            FROM SEGUROS.BENEF_PROP_AZUL
            WHERE NUM_PROPOSTA_AZUL =
            :DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_BENEFICIARIO)
							,0)
											FROM SEGUROS.BENEF_PROP_AZUL
											WHERE NUM_PROPOSTA_AZUL =
											'{this.NUM_PROPOSTA_AZUL}'
											WITH UR";

            return query;
        }
        public string NUM_BENEFICIARIO { get; set; }
        public string NUM_PROPOSTA_AZUL { get; set; }

        public static M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1 Execute(M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1 m_13700_00_BENEFICIARIO_DB_SELECT_1_Query1)
        {
            var ths = m_13700_00_BENEFICIARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_13700_00_BENEFICIARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_BENEFICIARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}