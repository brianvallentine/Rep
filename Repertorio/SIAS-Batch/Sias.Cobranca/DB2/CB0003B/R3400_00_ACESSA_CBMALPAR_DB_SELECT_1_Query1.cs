using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1 : QueryBasis<R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(A.VALOR_ACRESCIMO,0)
            + VALUE(A.VALOR_TARIFA,0)
            + VALUE(A.VALOR_VISTORIA,0)
            INTO :V0PDEV-VLACRESCIMO
            FROM SEGUROS.CB_MALA_PARCATRASO A
            WHERE A.NUM_APOLICE = :V1PARC-NUM-APOL
            AND A.NUM_ENDOSSO = :V1PARC-NRENDOS
            AND A.NUM_PARCELA = :V1PARC-NRPARCEL
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
				SELECT VALUE(A.VALOR_ACRESCIMO
							,0)
											+ VALUE(A.VALOR_TARIFA
							,0)
											+ VALUE(A.VALOR_VISTORIA
							,0)
											FROM SEGUROS.CB_MALA_PARCATRASO A
											WHERE A.NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND A.NUM_ENDOSSO = '{this.V1PARC_NRENDOS}'
											AND A.NUM_PARCELA = '{this.V1PARC_NRPARCEL}'
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
        public string V0PDEV_VLACRESCIMO { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1 Execute(R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1 r3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1)
        {
            var ths = r3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3400_00_ACESSA_CBMALPAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PDEV_VLACRESCIMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}