using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2000_GRAVA_PARCELA_DB_SELECT_1_Query1 : QueryBasis<B2000_GRAVA_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT NRPRRESS,
            TIPO_COBRANCA
            INTO :AUTA-NRPRRESS,
            :AUTA-TIPO-COBRANCA
            FROM SEGUROS.V0AUTOAPOL
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NRENDOS = :ENDO-NRENDOS
            AND SITUACAO = ' '
            ORDER BY 1,2
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DISTINCT NRPRRESS
							,
											TIPO_COBRANCA
											FROM SEGUROS.V0AUTOAPOL
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NRENDOS = '{this.ENDO_NRENDOS}'
											AND SITUACAO = ' '
											ORDER BY 1
							,2
											WITH UR";

            return query;
        }
        public string AUTA_NRPRRESS { get; set; }
        public string AUTA_TIPO_COBRANCA { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2000_GRAVA_PARCELA_DB_SELECT_1_Query1 Execute(B2000_GRAVA_PARCELA_DB_SELECT_1_Query1 b2000_GRAVA_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = b2000_GRAVA_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2000_GRAVA_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2000_GRAVA_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.AUTA_NRPRRESS = result[i++].Value?.ToString();
            dta.AUTA_TIPO_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}