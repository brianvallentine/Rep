using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P1010_05_INICIO_DB_SELECT_2_Query1 : QueryBasis<P1010_05_INICIO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BI001.IMP_SEGURADA_IX
            ,BI001.PRM_TOTAL
            INTO :VG103-VLR-IS
            ,:VG103-VLR-PREMIO
            FROM SEGUROS.BILHETE_COBERTURA BI001
            WHERE BI001.COD_PRODUTO = :BILCOBER-COD-PRODUTO
            AND BI001.RAMO_COBERTURA
            = :BILCOBER-RAMO-COBERTURA
            AND BI001.COD_OPCAO_PLANO
            = :BILCOBER-COD-OPCAO-PLANO
            AND :BILCOBER-DATA-INIVIGENCIA BETWEEN
            BI001.DATA_INIVIGENCIA AND
            BI001.DATA_TERVIGENCIA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT BI001.IMP_SEGURADA_IX
											,BI001.PRM_TOTAL
											FROM SEGUROS.BILHETE_COBERTURA BI001
											WHERE BI001.COD_PRODUTO = '{this.BILCOBER_COD_PRODUTO}'
											AND BI001.RAMO_COBERTURA
											= '{this.BILCOBER_RAMO_COBERTURA}'
											AND BI001.COD_OPCAO_PLANO
											= '{this.BILCOBER_COD_OPCAO_PLANO}'
											AND '{this.BILCOBER_DATA_INIVIGENCIA}' BETWEEN
											BI001.DATA_INIVIGENCIA AND
											BI001.DATA_TERVIGENCIA
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string VG103_VLR_IS { get; set; }
        public string VG103_VLR_PREMIO { get; set; }
        public string BILCOBER_DATA_INIVIGENCIA { get; set; }
        public string BILCOBER_COD_OPCAO_PLANO { get; set; }
        public string BILCOBER_RAMO_COBERTURA { get; set; }
        public string BILCOBER_COD_PRODUTO { get; set; }

        public static P1010_05_INICIO_DB_SELECT_2_Query1 Execute(P1010_05_INICIO_DB_SELECT_2_Query1 p1010_05_INICIO_DB_SELECT_2_Query1)
        {
            var ths = p1010_05_INICIO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P1010_05_INICIO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P1010_05_INICIO_DB_SELECT_2_Query1();
            var i = 0;
            dta.VG103_VLR_IS = result[i++].Value?.ToString();
            dta.VG103_VLR_PREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}