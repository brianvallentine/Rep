using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1 : QueryBasis<R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIST_PROP_FIDELIZ
            ( NUM_IDENTIFICACAO
            , DATA_SITUACAO
            , NSAS_SIVPF
            , NSL
            , SIT_PROPOSTA
            , SIT_COBRANCA_SIVPF
            , SIT_MOTIVO_SIVPF
            , COD_EMPRESA_SIVPF
            , COD_PRODUTO_SIVPF
            )
            VALUES (:DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO
            , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO:VIND-DTMOVTO
            , :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF
            , :DCLPROPOSTA-FIDELIZ.NSL
            , 'REJ'
            , 'SUS'
            , 99
            , :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF
            , :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_PROP_FIDELIZ ( NUM_IDENTIFICACAO , DATA_SITUACAO , NSAS_SIVPF , NSL , SIT_PROPOSTA , SIT_COBRANCA_SIVPF , SIT_MOTIVO_SIVPF , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF ) VALUES ({FieldThreatment(this.NUM_IDENTIFICACAO)} ,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.SISTEMAS_DATA_MOV_ABERTO))} , {FieldThreatment(this.NSAC_SIVPF)} , {FieldThreatment(this.NSL)} , 'REJ' , 'SUS' , 99 , {FieldThreatment(this.COD_EMPRESA_SIVPF)} , {FieldThreatment(this.COD_PRODUTO_SIVPF)})";

            return query;
        }
        public string NUM_IDENTIFICACAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string VIND_DTMOVTO { get; set; }
        public string NSAC_SIVPF { get; set; }
        public string NSL { get; set; }
        public string COD_EMPRESA_SIVPF { get; set; }
        public string COD_PRODUTO_SIVPF { get; set; }

        public static void Execute(R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1 r1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1)
        {
            var ths = r1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1610_00_INSERT_HISPROPFID_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}