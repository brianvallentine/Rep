using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1 : QueryBasis<R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_MORNATU_ANT ,
            IMP_MORNATU_ATU ,
            COD_OPERACAO
            INTO :MOVIMVGA-IMP-MORNATU-ANT ,
            :MOVIMVGA-IMP-MORNATU-ATU ,
            :MOVIMVGA-COD-OPERACAO
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND COD_OPERACAO = :RELATORI-COD-OPERACAO
            AND DATA_OPERACAO = :RELATORI-DATA-SOLICITACAO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IMP_MORNATU_ANT 
							,
											IMP_MORNATU_ATU 
							,
											COD_OPERACAO
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND COD_OPERACAO = '{this.RELATORI_COD_OPERACAO}'
											AND DATA_OPERACAO = '{this.RELATORI_DATA_SOLICITACAO}'
											WITH UR";

            return query;
        }
        public string MOVIMVGA_IMP_MORNATU_ANT { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ATU { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }

        public static R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1 Execute(R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1 r1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1)
        {
            var ths = r1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMVGA_IMP_MORNATU_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}