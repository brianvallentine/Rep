using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_RESSEGURO ,
            IND_CESSAO ,
            COD_TP_COBERTURA
            INTO :MRPROCOB-IND-RESSEGURO ,
            :MRPROCOB-IND-CESSAO ,
            :MRPROCOB-COD-TP-COBERTURA
            FROM SEGUROS.MR_PRODUTO_COBER
            WHERE COD_PRODUTO = :MRPROCOB-COD-PRODUTO
            AND COD_EMPRESA = :MRAPOCOB-COD-EMPRESA
            AND NUM_VERSAO = :MRAPOITE-NUM-VERSAO
            AND RAMO_COBERTURA = :MRAPOCOB-RAMO-COBERTURA
            AND MODALI_COBERTURA = :MRAPOCOB-MODALI-COBERTURA
            AND COD_COBERTURA = :MRAPOCOB-COD-COBERTURA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_RESSEGURO 
							,
											IND_CESSAO 
							,
											COD_TP_COBERTURA
											FROM SEGUROS.MR_PRODUTO_COBER
											WHERE COD_PRODUTO = '{this.MRPROCOB_COD_PRODUTO}'
											AND COD_EMPRESA = '{this.MRAPOCOB_COD_EMPRESA}'
											AND NUM_VERSAO = '{this.MRAPOITE_NUM_VERSAO}'
											AND RAMO_COBERTURA = '{this.MRAPOCOB_RAMO_COBERTURA}'
											AND MODALI_COBERTURA = '{this.MRAPOCOB_MODALI_COBERTURA}'
											AND COD_COBERTURA = '{this.MRAPOCOB_COD_COBERTURA}'
											WITH UR";

            return query;
        }
        public string MRPROCOB_IND_RESSEGURO { get; set; }
        public string MRPROCOB_IND_CESSAO { get; set; }
        public string MRPROCOB_COD_TP_COBERTURA { get; set; }
        public string MRAPOCOB_MODALI_COBERTURA { get; set; }
        public string MRAPOCOB_RAMO_COBERTURA { get; set; }
        public string MRAPOCOB_COD_COBERTURA { get; set; }
        public string MRPROCOB_COD_PRODUTO { get; set; }
        public string MRAPOCOB_COD_EMPRESA { get; set; }
        public string MRAPOITE_NUM_VERSAO { get; set; }

        public static R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1 r1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_PROD_COBT_DB_SELECT_1_Query1();
            var i = 0;
            dta.MRPROCOB_IND_RESSEGURO = result[i++].Value?.ToString();
            dta.MRPROCOB_IND_CESSAO = result[i++].Value?.ToString();
            dta.MRPROCOB_COD_TP_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}