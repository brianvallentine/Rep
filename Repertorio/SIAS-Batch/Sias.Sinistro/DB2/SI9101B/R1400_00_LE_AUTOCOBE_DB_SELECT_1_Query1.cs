using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1 : QueryBasis<R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            SIT_REGISTRO
            INTO :AUTOCOBE-IMP-SEGURADA-IX,
            :AUTOCOBE-SIT-REGISTRO
            FROM SEGUROS.AUTO_COBERTURAS
            WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE
            AND NUM_ITEM = :APOLIAUT-NUM-ITEM
            AND RAMO_COBERTURA = :SIARDEVC-COD-RAMO
            AND COD_COBERTURA = :AUTOCOBE-COD-COBERTURA
            AND DATA_INIVIGENCIA <= :SIARDEVC-DATA-OCORRENCIA
            AND DATA_TERVIGENCIA >= :SIARDEVC-DATA-OCORRENCIA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											SIT_REGISTRO
											FROM SEGUROS.AUTO_COBERTURAS
											WHERE NUM_APOLICE = '{this.SIARDEVC_NUM_APOLICE}'
											AND NUM_ITEM = '{this.APOLIAUT_NUM_ITEM}'
											AND RAMO_COBERTURA = '{this.SIARDEVC_COD_RAMO}'
											AND COD_COBERTURA = '{this.AUTOCOBE_COD_COBERTURA}'
											AND DATA_INIVIGENCIA <= '{this.SIARDEVC_DATA_OCORRENCIA}'
											AND DATA_TERVIGENCIA >= '{this.SIARDEVC_DATA_OCORRENCIA}'";

            return query;
        }
        public string AUTOCOBE_IMP_SEGURADA_IX { get; set; }
        public string AUTOCOBE_SIT_REGISTRO { get; set; }
        public string SIARDEVC_DATA_OCORRENCIA { get; set; }
        public string AUTOCOBE_COD_COBERTURA { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string APOLIAUT_NUM_ITEM { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }

        public static R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1 Execute(R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1 r1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_LE_AUTOCOBE_DB_SELECT_1_Query1();
            var i = 0;
            dta.AUTOCOBE_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.AUTOCOBE_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}