using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI5166B
{
    public class R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            ,NUM_IDENTIFICACAO
            ,COD_PRODUTO_SIVPF
            ,NUMCTAVEN
            ,DIGCTAVEN
            ,ORIGEM_PROPOSTA
            ,OPCAO_COBER
            ,COD_PLANO
            INTO :PROPOFID-NUM-PROPOSTA-SIVPF
            ,:PROPOFID-NUM-IDENTIFICACAO
            ,:PROPOFID-COD-PRODUTO-SIVPF
            ,:PROPOFID-NUMCTAVEN
            ,:PROPOFID-DIGCTAVEN
            ,:PROPOFID-ORIGEM-PROPOSTA
            ,:PROPOFID-OPCAO-COBER
            ,:PROPOFID-COD-PLANO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :BILHETE-NUM-BILHETE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											,NUM_IDENTIFICACAO
											,COD_PRODUTO_SIVPF
											,NUMCTAVEN
											,DIGCTAVEN
											,ORIGEM_PROPOSTA
											,OPCAO_COBER
											,COD_PLANO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.BILHETE_NUM_BILHETE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0210_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUMCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_DIGCTAVEN = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}