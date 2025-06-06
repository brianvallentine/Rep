using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005S
{
    public class M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1 : QueryBasis<M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_FONE ,
            DDI ,
            DDD ,
            NUM_FONE ,
            SITUACAO_FONE
            INTO :DCLPESSOA-TELEFONE.TIPO-FONE ,
            :DCLPESSOA-TELEFONE.DDI ,
            :DCLPESSOA-TELEFONE.DDD ,
            :DCLPESSOA-TELEFONE.NUM-FONE ,
            :DCLPESSOA-TELEFONE.SITUACAO-FONE
            FROM SEGUROS.PESSOA_TELEFONE
            WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA
            AND TIPO_FONE = :IND-TEL
            AND SEQ_FONE = :WS-MAX-SEQ-TEL
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT TIPO_FONE 
							,
											DDI 
							,
											DDD 
							,
											NUM_FONE 
							,
											SITUACAO_FONE
											FROM SEGUROS.PESSOA_TELEFONE
											WHERE COD_PESSOA = '{this.BI0005L_E_COD_PESSOA}'
											AND TIPO_FONE = '{this.IND_TEL}'
											AND SEQ_FONE = '{this.WS_MAX_SEQ_TEL}'
											WITH UR";

            return query;
        }
        public string TIPO_FONE { get; set; }
        public string DDI { get; set; }
        public string DDD { get; set; }
        public string NUM_FONE { get; set; }
        public string SITUACAO_FONE { get; set; }
        public string BI0005L_E_COD_PESSOA { get; set; }
        public string WS_MAX_SEQ_TEL { get; set; }
        public string IND_TEL { get; set; }

        public static M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1 Execute(M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1 m_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1)
        {
            var ths = m_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1();
            var i = 0;
            dta.TIPO_FONE = result[i++].Value?.ToString();
            dta.DDI = result[i++].Value?.ToString();
            dta.DDD = result[i++].Value?.ToString();
            dta.NUM_FONE = result[i++].Value?.ToString();
            dta.SITUACAO_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}