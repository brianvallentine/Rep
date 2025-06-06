using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NUM_ITEM,
            NUM_ENDOSSO,
            RAMO_COBERTURA,
            COD_COBERTURA,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA
            INTO :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-APOLICE,
            :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ITEM,
            :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ENDOSSO,
            :DCLAPOLICE-COBERTURAS.APOLICOB-RAMO-COBERTURA,
            :DCLAPOLICE-COBERTURAS.APOLICOB-COD-COBERTURA,
            :DCLAPOLICE-COBERTURAS.APOLICOB-DATA-INIVIGENCIA,
            :DCLAPOLICE-COBERTURAS.APOLICOB-DATA-TERVIGENCIA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE =
            :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-APOLICE
            AND NUM_ENDOSSO =
            :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ENDOSSO
            AND NUM_ITEM =
            :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ITEM
            AND RAMO_COBERTURA =
            :DCLAPOLICE-COBERTURAS.APOLICOB-RAMO-COBERTURA
            AND COD_COBERTURA =
            :DCLAPOLICE-COBERTURAS.APOLICOB-COD-COBERTURA
            AND DATA_INIVIGENCIA =
            :DCLAPOLICE-COBERTURAS.APOLICOB-DATA-INIVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NUM_ITEM
							,
											NUM_ENDOSSO
							,
											RAMO_COBERTURA
							,
											COD_COBERTURA
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE =
											'{this.APOLICOB_NUM_APOLICE}'
											AND NUM_ENDOSSO =
											'{this.APOLICOB_NUM_ENDOSSO}'
											AND NUM_ITEM =
											'{this.APOLICOB_NUM_ITEM}'
											AND RAMO_COBERTURA =
											'{this.APOLICOB_RAMO_COBERTURA}'
											AND COD_COBERTURA =
											'{this.APOLICOB_COD_COBERTURA}'
											AND DATA_INIVIGENCIA =
											'{this.APOLICOB_DATA_INIVIGENCIA}'
											WITH UR";

            return query;
        }
        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ITEM { get; set; }
        public string APOLICOB_NUM_ENDOSSO { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_DATA_INIVIGENCIA { get; set; }
        public string APOLICOB_DATA_TERVIGENCIA { get; set; }

        public static R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1 Execute(R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1 r0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = r0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.APOLICOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}