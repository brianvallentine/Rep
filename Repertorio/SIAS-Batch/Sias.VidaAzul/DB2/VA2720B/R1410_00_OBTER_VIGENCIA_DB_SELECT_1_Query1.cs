using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1>
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
            DATA_TERVIGENCIA,
            IMP_SEGURADA_IX
            INTO :APOLICOB-NUM-APOLICE,
            :APOLICOB-NUM-ITEM,
            :APOLICOB-NUM-ENDOSSO,
            :APOLICOB-RAMO-COBERTURA,
            :APOLICOB-COD-COBERTURA,
            :APOLICOB-DATA-INIVIGENCIA,
            :APOLICOB-DATA-TERVIGENCIA,
            :APOLICOB-IMP-SEGURADA-IX
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO =
            (SELECT MAX(OCORR_HISTORICO)
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM)
            FETCH FIRST 1 ROW ONLY
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
							,
											IMP_SEGURADA_IX
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO =
											(SELECT MAX(OCORR_HISTORICO)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}')
											FETCH FIRST 1 ROW ONLY
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
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1 Execute(R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1 r1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = r1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLICOB_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.APOLICOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}