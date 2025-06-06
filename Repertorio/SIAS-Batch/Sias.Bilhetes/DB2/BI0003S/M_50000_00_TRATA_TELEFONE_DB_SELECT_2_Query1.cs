using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1 : QueryBasis<M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DDI ,
            DDD ,
            NUM_FONE
            INTO :DCLPESSOA-TELEFONE.DDI ,
            :DCLPESSOA-TELEFONE.DDD ,
            :DCLPESSOA-TELEFONE.NUM-FONE
            FROM SEGUROS.PESSOA_TELEFONE
            WHERE COD_PESSOA = :WS-COD-PES-ATU
            AND TIPO_FONE = :IND-TEL
            AND SEQ_FONE = :WS-MAX-SEQ-TEL
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DDI 
							,
											DDD 
							,
											NUM_FONE
											FROM SEGUROS.PESSOA_TELEFONE
											WHERE COD_PESSOA = '{this.WS_COD_PES_ATU}'
											AND TIPO_FONE = '{this.IND_TEL}'
											AND SEQ_FONE = '{this.WS_MAX_SEQ_TEL}'
											WITH UR";

            return query;
        }
        public string DDI { get; set; }
        public string DDD { get; set; }
        public string NUM_FONE { get; set; }
        public string WS_COD_PES_ATU { get; set; }
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
            dta.DDI = result[i++].Value?.ToString();
            dta.DDD = result[i++].Value?.ToString();
            dta.NUM_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}