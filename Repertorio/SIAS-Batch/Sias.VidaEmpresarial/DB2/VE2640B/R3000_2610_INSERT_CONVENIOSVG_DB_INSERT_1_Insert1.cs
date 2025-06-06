using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1 : QueryBasis<R3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CONVENIOS_VG
            (NUM_APOLICE ,
            CODSUBES ,
            COD_SEGURO ,
            COD_AJUSTE ,
            COD_COMISSAO ,
            COD_NAOACEITE ,
            CODUSU ,
            TIMESTAMP ,
            COD_CONV_CARTAO )
            VALUES (:CONVEVG-NUM-APOLICE,
            :CONVEVG-CODSUBES ,
            :CONVEVG-COD-SEGURO ,
            :CONVEVG-COD-AJUSTE ,
            :CONVEVG-COD-COMISSAO,
            :CONVEVG-COD-NAOACEITE,
            :CONVEVG-CODUSU,
            CURRENT TIMESTAMP,
            :CONVEVG-COD-CONV-CARTAO )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONVENIOS_VG (NUM_APOLICE , CODSUBES , COD_SEGURO , COD_AJUSTE , COD_COMISSAO , COD_NAOACEITE , CODUSU , TIMESTAMP , COD_CONV_CARTAO ) VALUES ({FieldThreatment(this.CONVEVG_NUM_APOLICE)}, {FieldThreatment(this.CONVEVG_CODSUBES)} , {FieldThreatment(this.CONVEVG_COD_SEGURO)} , {FieldThreatment(this.CONVEVG_COD_AJUSTE)} , {FieldThreatment(this.CONVEVG_COD_COMISSAO)}, {FieldThreatment(this.CONVEVG_COD_NAOACEITE)}, {FieldThreatment(this.CONVEVG_CODUSU)}, CURRENT TIMESTAMP, {FieldThreatment(this.CONVEVG_COD_CONV_CARTAO)} )";

            return query;
        }
        public string CONVEVG_NUM_APOLICE { get; set; }
        public string CONVEVG_CODSUBES { get; set; }
        public string CONVEVG_COD_SEGURO { get; set; }
        public string CONVEVG_COD_AJUSTE { get; set; }
        public string CONVEVG_COD_COMISSAO { get; set; }
        public string CONVEVG_COD_NAOACEITE { get; set; }
        public string CONVEVG_CODUSU { get; set; }
        public string CONVEVG_COD_CONV_CARTAO { get; set; }

        public static void Execute(R3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1 r3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1)
        {
            var ths = r3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_2610_INSERT_CONVENIOSVG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}