using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0095B
{
    public class R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1 : QueryBasis<R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(A.NUM_CHEQUE_INTERNO,0),
            VALUE(A.DIG_CHEQUE_INTERNO,0),
            VALUE(B.COD_BANCO,0),
            VALUE(B.COD_AGENCIA,0),
            VALUE(B.NUM_CHEQUE,0),
            VALUE(B.SERIE_CHEQUE, ' ' ),
            VALUE(B.DIG_CHEQUE,0)
            INTO :CHEQUEMI-NUM-CHEQUE-INTERNO,
            :CHEQUEMI-DIG-CHEQUE-INTERNO,
            :LOTECHEQ-COD-BANCO,
            :LOTECHEQ-COD-AGENCIA,
            :LOTECHEQ-NUM-CHEQUE,
            :LOTECHEQ-SERIE-CHEQUE,
            :LOTECHEQ-DIG-CHEQUE
            FROM SEGUROS.CHEQUES_EMITIDOS A,
            SEGUROS.LOTE_CHEQUES B
            WHERE A.NUM_DOCUMENTO = :CHEQUEMI-NUM-DOCUMENTO
            AND A.DATA_MOVIMENTO = :SISTEMAS-DATULT-PROCESSAMEN
            AND B.NUM_CHEQUE_INTERNO = A.NUM_CHEQUE_INTERNO
            AND B.DIG_CHEQUE_INTERNO = A.DIG_CHEQUE_INTERNO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(A.NUM_CHEQUE_INTERNO
							,0)
							,
											VALUE(A.DIG_CHEQUE_INTERNO
							,0)
							,
											VALUE(B.COD_BANCO
							,0)
							,
											VALUE(B.COD_AGENCIA
							,0)
							,
											VALUE(B.NUM_CHEQUE
							,0)
							,
											VALUE(B.SERIE_CHEQUE
							, ' ' )
							,
											VALUE(B.DIG_CHEQUE
							,0)
											FROM SEGUROS.CHEQUES_EMITIDOS A
							,
											SEGUROS.LOTE_CHEQUES B
											WHERE A.NUM_DOCUMENTO = '{this.CHEQUEMI_NUM_DOCUMENTO}'
											AND A.DATA_MOVIMENTO = '{this.SISTEMAS_DATULT_PROCESSAMEN}'
											AND B.NUM_CHEQUE_INTERNO = A.NUM_CHEQUE_INTERNO
											AND B.DIG_CHEQUE_INTERNO = A.DIG_CHEQUE_INTERNO";

            return query;
        }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }
        public string CHEQUEMI_DIG_CHEQUE_INTERNO { get; set; }
        public string LOTECHEQ_COD_BANCO { get; set; }
        public string LOTECHEQ_COD_AGENCIA { get; set; }
        public string LOTECHEQ_NUM_CHEQUE { get; set; }
        public string LOTECHEQ_SERIE_CHEQUE { get; set; }
        public string LOTECHEQ_DIG_CHEQUE { get; set; }
        public string SISTEMAS_DATULT_PROCESSAMEN { get; set; }
        public string CHEQUEMI_NUM_DOCUMENTO { get; set; }

        public static R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1 Execute(R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1 r1010_ACESSA_CHEQUE_DB_SELECT_1_Query1)
        {
            var ths = r1010_ACESSA_CHEQUE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CHEQUEMI_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.CHEQUEMI_DIG_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.LOTECHEQ_COD_BANCO = result[i++].Value?.ToString();
            dta.LOTECHEQ_COD_AGENCIA = result[i++].Value?.ToString();
            dta.LOTECHEQ_NUM_CHEQUE = result[i++].Value?.ToString();
            dta.LOTECHEQ_SERIE_CHEQUE = result[i++].Value?.ToString();
            dta.LOTECHEQ_DIG_CHEQUE = result[i++].Value?.ToString();
            return dta;
        }

    }
}