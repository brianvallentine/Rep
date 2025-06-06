using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1 : QueryBasis<M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA
            INTO :PROPAUTOM-BENEFI
            FROM SEGUROS.V0BENEFIPROP
            WHERE COD_FONTE = :PROPVA-FONTE
            AND NUM_PROPOSTA = :FONTE-PROPAUTOM
            AND NUM_BENEFICIARIO = :BENEF-NRBENEF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA
											FROM SEGUROS.V0BENEFIPROP
											WHERE COD_FONTE = '{this.PROPVA_FONTE}'
											AND NUM_PROPOSTA = '{this.FONTE_PROPAUTOM}'
											AND NUM_BENEFICIARIO = '{this.BENEF_NRBENEF}'
											WITH UR";

            return query;
        }
        public string PROPAUTOM_BENEFI { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string BENEF_NRBENEF { get; set; }
        public string PROPVA_FONTE { get; set; }

        public static M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1 Execute(M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1 m_8120_INICIO_VERIFICA_DB_SELECT_1_Query1)
        {
            var ths = m_8120_INICIO_VERIFICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8120_INICIO_VERIFICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPAUTOM_BENEFI = result[i++].Value?.ToString();
            return dta;
        }

    }
}