using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NUM_ENDOSSO ,
            RAMO_EMISSOR,
            COD_PRODUTO ,
            COD_SUBGRUPO,
            COD_FONTE ,
            DATA_EMISSAO,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            COD_MOEDA_IMP,
            COD_MOEDA_PRM,
            SIT_REGISTRO
            INTO :ENDOSSOS-NUM-APOLICE ,
            :ENDOSSOS-NUM-ENDOSSO ,
            :ENDOSSOS-RAMO-EMISSOR,
            :ENDOSSOS-COD-PRODUTO ,
            :ENDOSSOS-COD-SUBGRUPO,
            :ENDOSSOS-COD-FONTE ,
            :ENDOSSOS-DATA-EMISSAO,
            :ENDOSSOS-DATA-INIVIGENCIA,
            :ENDOSSOS-DATA-TERVIGENCIA,
            :ENDOSSOS-COD-MOEDA-IMP,
            :ENDOSSOS-COD-MOEDA-PRM,
            :ENDOSSOS-SIT-REGISTRO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NUM_ENDOSSO 
							,
											RAMO_EMISSOR
							,
											COD_PRODUTO 
							,
											COD_SUBGRUPO
							,
											COD_FONTE 
							,
											DATA_EMISSAO
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
							,
											COD_MOEDA_IMP
							,
											COD_MOEDA_PRM
							,
											SIT_REGISTRO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_SUBGRUPO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_DATA_EMISSAO { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string ENDOSSOS_COD_MOEDA_IMP { get; set; }
        public string ENDOSSOS_COD_MOEDA_PRM { get; set; }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }

        public static R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.ENDOSSOS_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}