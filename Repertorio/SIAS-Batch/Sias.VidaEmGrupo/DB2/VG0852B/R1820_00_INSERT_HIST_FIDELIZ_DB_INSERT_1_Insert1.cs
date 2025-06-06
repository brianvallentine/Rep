using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1 : QueryBasis<R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIST_PROP_FIDELIZ
            (NUM_IDENTIFICACAO ,
            DATA_SITUACAO ,
            NSAS_SIVPF ,
            NSL ,
            SIT_PROPOSTA ,
            SIT_COBRANCA_SIVPF ,
            SIT_MOTIVO_SIVPF ,
            COD_EMPRESA_SIVPF ,
            COD_PRODUTO_SIVPF )
            VALUES (:PROPOFID-NUM-IDENTIFICACAO ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            :PROPOFID-NSAS-SIVPF ,
            :PROPOFID-NSL ,
            'CAN' ,
            :HISPROFI-SIT-COBRANCA-SIVPF ,
            100 ,
            :PROPOFID-COD-EMPRESA-SIVPF ,
            :PROPOFID-COD-PRODUTO-SIVPF )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_PROP_FIDELIZ (NUM_IDENTIFICACAO , DATA_SITUACAO , NSAS_SIVPF , NSL , SIT_PROPOSTA , SIT_COBRANCA_SIVPF , SIT_MOTIVO_SIVPF , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF ) VALUES ({FieldThreatment(this.PROPOFID_NUM_IDENTIFICACAO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.PROPOFID_NSAS_SIVPF)} , {FieldThreatment(this.PROPOFID_NSL)} , 'CAN' , {FieldThreatment(this.HISPROFI_SIT_COBRANCA_SIVPF)} , 100 , {FieldThreatment(this.PROPOFID_COD_EMPRESA_SIVPF)} , {FieldThreatment(this.PROPOFID_COD_PRODUTO_SIVPF)} )";

            return query;
        }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PROPOFID_NSAS_SIVPF { get; set; }
        public string PROPOFID_NSL { get; set; }
        public string HISPROFI_SIT_COBRANCA_SIVPF { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }

        public static void Execute(R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1 r1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1)
        {
            var ths = r1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1820_00_INSERT_HIST_FIDELIZ_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}