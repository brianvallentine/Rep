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
    public class R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1 : QueryBasis<R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(A.NUM_TITULO,0)
            INTO :V0PARC-NRTIT
            FROM SEGUROS.CB_MALA_PARCATRASO A
            WHERE A.NUM_APOLICE = :V0PARC-NUMAPOL
            AND A.NUM_ENDOSSO = :V0PARC-NRENDOS
            AND A.NUM_PARCELA = :V0PARC-NRPARCEL
            AND A.DATA_MOVIMENTO =
            (SELECT MAX(B.DATA_MOVIMENTO)
            FROM SEGUROS.CB_MALA_PARCATRASO B
            WHERE
            B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND B.NUM_PARCELA = A.NUM_PARCELA)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(A.NUM_TITULO
							,0)
											FROM SEGUROS.CB_MALA_PARCATRASO A
											WHERE A.NUM_APOLICE = '{this.V0PARC_NUMAPOL}'
											AND A.NUM_ENDOSSO = '{this.V0PARC_NRENDOS}'
											AND A.NUM_PARCELA = '{this.V0PARC_NRPARCEL}'
											AND A.DATA_MOVIMENTO =
											(SELECT MAX(B.DATA_MOVIMENTO)
											FROM SEGUROS.CB_MALA_PARCATRASO B
											WHERE
											B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND B.NUM_PARCELA = A.NUM_PARCELA)
											WITH UR";

            return query;
        }
        public string V0PARC_NRTIT { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_NUMAPOL { get; set; }
        public string V0PARC_NRENDOS { get; set; }

        public static R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1 Execute(R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1 r3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1)
        {
            var ths = r3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3300_00_SELECT_CBMALPAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}