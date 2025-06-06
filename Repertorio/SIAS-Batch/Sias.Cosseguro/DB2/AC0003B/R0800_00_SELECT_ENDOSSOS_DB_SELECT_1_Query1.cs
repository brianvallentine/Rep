using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0003B
{
    public class R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NUM_ENDOSSO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            TIPO_ENDOSSO ,
            SIT_REGISTRO
            INTO :ENDOSSOS-NUM-APOLICE ,
            :ENDOSSOS-NUM-ENDOSSO ,
            :ENDOSSOS-DATA-INIVIGENCIA ,
            :ENDOSSOS-DATA-TERVIGENCIA ,
            :ENDOSSOS-TIPO-ENDOSSO ,
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
											DATA_INIVIGENCIA 
							,
											DATA_TERVIGENCIA 
							,
											TIPO_ENDOSSO 
							,
											SIT_REGISTRO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string ENDOSSOS_TIPO_ENDOSSO { get; set; }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }

        public static R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_TIPO_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}