using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE ,
            A.NRENDOS ,
            A.NRPARCEL ,
            B.CODPRODU
            INTO :V0PARC-NUMAPOL ,
            :V0PARC-NRENDOS ,
            :V0PARC-NRPARCEL ,
            :V1ENDO-CODPRODU:VIND-CODPRODU
            FROM SEGUROS.V0PARCELA A,
            SEGUROS.V1ENDOSSO B
            WHERE A.NRTIT = :V0MCOB-NRTIT
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NRENDOS = A.NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE 
							,
											A.NRENDOS 
							,
											A.NRPARCEL 
							,
											B.CODPRODU
											FROM SEGUROS.V0PARCELA A
							,
											SEGUROS.V1ENDOSSO B
											WHERE A.NRTIT = '{this.V0MCOB_NRTIT}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NRENDOS = A.NRENDOS
											WITH UR";

            return query;
        }
        public string V0PARC_NUMAPOL { get; set; }
        public string V0PARC_NRENDOS { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string V0MCOB_NRTIT { get; set; }

        public static R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 Execute(R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 r3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3250_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_NUMAPOL = result[i++].Value?.ToString();
            dta.V0PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V0PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.V1ENDO_CODPRODU) ? "-1" : "0";
            return dta;
        }

    }
}