using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            VALUES ( 'PF0605B' ,
            CURRENT DATE,
            'PF' ,
            'PF0648B' ,
            0,
            0,
            CURRENT DATE,
            CURRENT DATE,
            CURRENT DATE,
            0,
            0,
            0,
            0,
            0,
            :DCLAPOLICES.APOLICES-RAMO-EMISSOR,
            :DCLPROPOSTAS-VA.COD-PRODUTO,
            0,
            :DCLAPOLICES.APOLICES-NUM-APOLICE,
            0,
            0,
            :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF,
            0,
            0,
            0,
            :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            '0' ,
            '0' ,
            0,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS VALUES ( 'PF0605B' , CURRENT DATE, 'PF' , 'PF0648B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, {FieldThreatment(this.APOLICES_RAMO_EMISSOR)}, {FieldThreatment(this.COD_PRODUTO)}, 0, {FieldThreatment(this.APOLICES_NUM_APOLICE)}, 0, 0, {FieldThreatment(this.NUM_PROPOSTA_SIVPF)}, 0, 0, 0, {FieldThreatment(this.COD_PRODUTO_SIVPF)}, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , '0' , '0' , 0, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string COD_PRODUTO { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }
        public string COD_PRODUTO_SIVPF { get; set; }

        public static void Execute(M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1 m_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1)
        {
            var ths = m_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}