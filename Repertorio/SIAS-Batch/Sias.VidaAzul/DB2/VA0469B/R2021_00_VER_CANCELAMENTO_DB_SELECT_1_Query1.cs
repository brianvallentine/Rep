using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1 : QueryBasis<R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.NUM_CERTIFICADO ,
            T1.COD_OPERACAO ,
            T1.DATA_OPERACAO
            INTO :MOVIMVGA-NUM-CERTIFICADO ,
            :MOVIMVGA-COD-OPERACAO ,
            :MOVIMVGA-DATA-OPERACAO
            FROM SEGUROS.MOVIMENTO_VGAP T1
            WHERE T1.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND T1.COD_OPERACAO BETWEEN 0400 AND 0499
            AND NOT EXISTS
            ( SELECT T2.NUM_CERTIFICADO
            FROM SEGUROS.MOVIMENTO_VGAP T2
            WHERE T2.NUM_CERTIFICADO = T1.NUM_CERTIFICADO
            AND T2.COD_OPERACAO BETWEEN 0500 AND 0599
            AND T2.DATA_OPERACAO > T1.DATA_OPERACAO
            )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT T1.NUM_CERTIFICADO 
							,
											T1.COD_OPERACAO 
							,
											T1.DATA_OPERACAO
											FROM SEGUROS.MOVIMENTO_VGAP T1
											WHERE T1.NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND T1.COD_OPERACAO BETWEEN 0400 AND 0499
											AND NOT EXISTS
											( SELECT T2.NUM_CERTIFICADO
											FROM SEGUROS.MOVIMENTO_VGAP T2
											WHERE T2.NUM_CERTIFICADO = T1.NUM_CERTIFICADO
											AND T2.COD_OPERACAO BETWEEN 0500 AND 0599
											AND T2.DATA_OPERACAO > T1.DATA_OPERACAO
											)
											WITH UR";

            return query;
        }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string MOVIMVGA_DATA_OPERACAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1 Execute(R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1 r2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}